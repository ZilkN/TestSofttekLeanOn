using System.Collections.Generic;

namespace ShoppingCartTestLeanOn.Taxes
{
    /*This class is managing the strategies for the taxes, we can have a lot more of strategies for example, working with different taxes in differente states for the same products*/
    public class TaxCalculatorFactory
    {
        private readonly Dictionary<string, ITaxCalculator> _taxCalculators;

        public TaxCalculatorFactory()
        {
            _taxCalculators = new Dictionary<string, ITaxCalculator>();
            RegisterInFactory("Local", new TaxCalculator());
            RegisterInFactory("California", new TaxCalculator());
        }

        public void RegisterInFactory(string strategy, ITaxCalculator taxCalc)
        {
            _taxCalculators.Add(strategy, taxCalc);
        }

        public ITaxCalculator GetTaxCalculator(string strategy)
        {
            var taxCalc = (ITaxCalculator)_taxCalculators[strategy];
            return taxCalc;
        }
    }
}