using BackgRPC.Protos;
using BackgRPC.Services.GrpcStreaming;
using BackgRPC.Services.GrpcStreaming.Models;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace BackgRPC.Services
{
    public class TimeService : TimeProtoService.TimeProtoServiceBase
    {
        private GrpcStreamingConfig config => new GrpcStreamingConfig()
            .SetDelay(1500)
            .SetInfinite(true);

        private readonly IGrpcStreamingService _grpcStreamingService;

        public TimeService(
            IGrpcStreamingService grpcStreamingService)
        {
            _grpcStreamingService = grpcStreamingService;
        }

        public override Task GetCurrentTimeStream(
            Empty request,
            IServerStreamWriter<CurrentTimeModel> responseStream,
            ServerCallContext context) => _grpcStreamingService.StreamingAsync(async () => await Handle(responseStream), context, config, () => Console.WriteLine("ENDED"));

        private Task Handle(IServerStreamWriter<CurrentTimeModel> responseStream) => responseStream.WriteAsync(new CurrentTimeModel
        {
            Timestamp = Timestamp.FromDateTime(DateTime.UtcNow)
        });
    }
}
