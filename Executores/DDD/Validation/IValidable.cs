
namespace Executores
{
    public interface IValidable
    {
        bool estValide();
        ListeMessagesValidation donnerLesMessagesDeValidation();
    }
}
