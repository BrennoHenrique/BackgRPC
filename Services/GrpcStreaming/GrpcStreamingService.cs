using BackgRPC.Services.GrpcStreaming.Models;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace BackgRPC.Services.GrpcStreaming
{
    public class GrpcStreamingService : IGrpcStreamingService
    {
        public async Task StreamingAsync(Action handle, ServerCallContext context, GrpcStreamingConfig config, Action endedCallback = null)
        {
            for (int index = 0; config.Infinite || index < config.Limit; index++)
            {
                if (context.CancellationToken.IsCancellationRequested)
                    break;

                handle();

                await Task.Delay(config.Delay);
            }

            if (endedCallback is not null)
                endedCallback();
        }
    }
}