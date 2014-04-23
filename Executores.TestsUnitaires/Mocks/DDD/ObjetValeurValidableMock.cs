
namespace Executores.TestsUnitaires
{
    public class ObjetValeurValidableMock : ObjetValeurValidable
    {
        public ObjetValeurValidableMock(string valeur) : base(valeur) { }

        public override MessageValidation donnerLErreur()
        {
            throw new System.NotImplementedException();
        }
    }
}
