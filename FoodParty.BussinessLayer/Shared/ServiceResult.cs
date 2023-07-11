namespace FoodParty.ApplicationServices.Shared
{
    public class ServiceResult<TData>
    {
        public string Message { get; set; }
        public bool IsSucceeded { get; set; }
        public TData Data { get; set; }
    }
}
