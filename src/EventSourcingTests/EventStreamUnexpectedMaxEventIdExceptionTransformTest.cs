﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Marten.Exceptions;
using Marten.Testing.Harness;
using Shouldly;
using Xunit;

namespace EventSourcingTests;

public class EventStreamUnexpectedMaxEventIdExceptionTransformTest: IntegrationContext
{
    public EventStreamUnexpectedMaxEventIdExceptionTransformTest(DefaultStoreFixture fixture):
        base(fixture)
    {
    }

    [Fact]
    public async Task throw_transformed_exception_with_details_redacted()
    {
        var streamId = Guid.NewGuid();
        var joined = new MembersJoined { Members = new[] { "Rand", "Matt", "Perrin", "Thom" } };
        var departed = new MembersDeparted { Members = new[] { "Thom" } };
        theSession.Events.StartStream<Quest>(streamId, joined);
        theSession.Events.Append(streamId, departed);
        await theSession.SaveChangesAsync();

        var forceEventStreamUnexpectedMaxEventIdException = async () =>
        {
            await Parallel.ForEachAsync(Enumerable.Range(1, 5), async (_, token) =>
            {
                await using var session = theStore.OpenSession();
                session.Events.Append(streamId, departed);
                await session.SaveChangesAsync(token);
            });
        };

        Should.Throw<EventStreamUnexpectedMaxEventIdException>(forceEventStreamUnexpectedMaxEventIdException)
            .Message.ShouldBe("duplicate key value violates unique constraint \"pk_mt_events_stream_and_version\"");
    }

    [Fact]
    public async Task throw_transformed_exception_with_details_available()
    {
        var connectionString = ConnectionSource.ConnectionString + ";Include Error Detail=true";
        StoreOptions(storeOptions => storeOptions.Connection(connectionString));

        var streamId = Guid.NewGuid();
        var joined = new MembersJoined { Members = new[] { "Rand", "Matt", "Perrin", "Thom" } };
        var departed = new MembersDeparted { Members = new[] { "Thom" } };
        theSession.Events.StartStream<Quest>(streamId, joined);
        theSession.Events.Append(streamId, departed);
        await theSession.SaveChangesAsync();

        async Task ForceEventStreamUnexpectedMaxEventIdException()
        {
            await Parallel.ForEachAsync(Enumerable.Range(1, 30), async (_, token) =>
            {
                await using var session = theStore.OpenSession();
                session.Events.Append(streamId, departed);
                await session.SaveChangesAsync(token);
            });
        }

        var expectedPattern =
            "Unexpected starting version number for event stream '" + streamId + "', expected [0-9]{1,2} but was [0-9]{1,2}";
        Should.Throw<EventStreamUnexpectedMaxEventIdException>(ForceEventStreamUnexpectedMaxEventIdException)
            .Message.ShouldMatch(expectedPattern);
    }
}
