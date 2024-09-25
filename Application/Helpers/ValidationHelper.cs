namespace Application.Helpers
{
    public class ValidationHelper
    {
        public static bool ValidateViewModelId(int id)
        {
            return id > 0;
        }
    }
}
