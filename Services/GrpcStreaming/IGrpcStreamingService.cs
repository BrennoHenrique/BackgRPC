using BackgRPC.Services.GrpcStreaming.Models;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace BackgRPC.Services.GrpcStreaming
{
    public interface IGrpcStreamingService
    {
        Task StreamingAsync(Action callback, ServerCallContext context, GrpcStreamingConfig config, Action endedCallback = default);
    }
}