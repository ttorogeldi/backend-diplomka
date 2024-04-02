namespace Assignment.DTO
{
    public class GeneralResponseDTO
    {
        public bool status { get; set; }
        public string message { get; set; }
        public object? data { get; set; }

        public GeneralResponseDTO(bool status,string message)
        {
            this.status = status;
            this.message = message;
        }
        public GeneralResponseDTO(bool status, string message,object data)
        {
            this.status = status;
            this.message = message;
            this.data = data;
        }
    }
}
