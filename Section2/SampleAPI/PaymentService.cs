


namespace SampleAPI
{
    public interface IPaymentService
    {
        string GetMessage();
    }

    public class PaymentService : IPaymentService
    {
        public string GetMessage() => "Pay Me!";
    }

    public class ExternalPaymentService : IPaymentService
    {
        public string GetMessage() => "Pay Me!, I'm an external Service!";
    }
}