
namespace Executores
{
    public interface IObjetValeurValidable
    {
        bool estValide();
        Erreur donnerLErreur();
    }
}
