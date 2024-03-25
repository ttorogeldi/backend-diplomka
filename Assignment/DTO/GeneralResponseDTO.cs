namespace Assignment.DTO
{
    public class GeneralResponseDTO
    {
        public bool ststus { get; set; }
        public string message { get; set; }
        public object? data { get; set; }

        public GeneralResponseDTO(bool status,string message)
        {
            this.ststus = status;
            this.message = message;
        }
        public GeneralResponseDTO(bool status, string message,object data)
        {
            this.ststus=status;
            this.message = message;
            this.data = data;
        }
    }
}
