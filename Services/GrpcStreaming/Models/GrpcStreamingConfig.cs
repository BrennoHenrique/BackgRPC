namespace BackgRPC.Services.GrpcStreaming.Models
{
    public class GrpcStreamingConfig
    {
        public int Delay { get; private set; } = 1000;
        public int Limit { get; private set; } = 0;
        public bool Infinite { get; private set; } = true;

        ///<summary>
        ///<param name="delay">Delay de verifição representado em milissegundos. Valor mínimo 300.</param>
        ///</summary>
        public GrpcStreamingConfig SetDelay(int delay)
        {
            Delay = delay < 300 ? 300 : delay;
            return this;
        }

        ///<summary>
        ///<param name="limit">Limite de verifições. Valor mínimo 1.</param>
        ///</summary>
        public GrpcStreamingConfig SetLimit(int limit)
        {
            Limit = limit < 1 ? 1 : limit;
            return this;
        }

        ///<summary>
        ///<param name="infinite">Define se as verificações serão infinitas.<br/>
        ///Caso <b>false</b>: será setado o valor mínimo de verificações.</param>
        ///</summary>
        public GrpcStreamingConfig SetInfinite(bool infinite)
        {
            Infinite = infinite;
            return infinite ? this : Limit > 0 ? this : SetLimit(0);
        }
    }
}