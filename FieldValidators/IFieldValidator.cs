using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub.FieldValidators;

public delegate bool FieldValidatorDlgt(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage);
public interface IFieldValidator
{
    void InitializeValidatorDelegates();
    string[] FieldArray { get; }
    FieldValidatorDlgt ValidatorDlgt { get; }
}
