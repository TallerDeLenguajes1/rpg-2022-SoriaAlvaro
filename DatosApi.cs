namespace DatosPJApi{
    public class Datum
    {
        public string? name { get; set; }
        public string? birthday { get; set; }
    }

    public class DatosApi
    {
        public string? status { get; set; }
        public int code { get; set; }
        public int total { get; set; }
        public List<Datum>? data { get; set; }
    }

    public class Result
    {
        public string? index { get; set; }
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class Classes_Monsters
    {
        public int count { get; set; }
        public List<Result>? results { get; set; }
    }
}