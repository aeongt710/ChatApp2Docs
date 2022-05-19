namespace ChatApp2Docs.Models.APIResponseModels
{
    public class CommonResponse<T>
    {
        public string message { get; set; }
        public int status { get; set; }
        public T dataenum { get; set; }
    }
}
