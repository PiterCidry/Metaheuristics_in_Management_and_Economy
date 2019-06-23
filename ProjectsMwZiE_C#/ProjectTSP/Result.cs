namespace ProjectTSP
{
    public class Result
    {
        public int Iterations { get; set; }
        public int PopulationSize { get; set; }
        public double Pc { get; set; }
        public double Pm { get; set; }
        public double Pi { get; set; }
        public long ElapsedMilliseconds { get; set; }
        public double BestGen { get; set; }
        public double BestFitness { get; set; }
    }
}
