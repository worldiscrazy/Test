using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{

    //[AttributeUsage(AttributeTargets.Struct)]
    public abstract class AbstractValidateAttribute : Attribute
    {
        public abstract bool Validate(object oValue);
    }

    public class EmptyAttribute : AbstractValidateAttribute
    {
        public override bool Validate(object oValue)
        {
            return oValue != null;
        }
    }

    public class LengthAttribute : AbstractValidateAttribute
    {
        private int _Min = 0;
        private int _Max = 0;
        public LengthAttribute(int min, int max)
        {
            this._Min = min;
            this._Max = max;
        }

        public override bool Validate(object oValue)
        {
            return oValue != null && !string.IsNullOrWhiteSpace(oValue.ToString())
                && oValue.ToString().Length >= this._Min && oValue.ToString().Length <= this._Max;
        }
    }

}
