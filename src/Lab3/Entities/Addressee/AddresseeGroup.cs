using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class AddresseeGroup : IAddressee
{
    private readonly IReadOnlyCollection<IAddressee> _addressees;

    public AddresseeGroup(IEnumerable<IAddressee> addressees)
    {
        _addressees = addressees.ToArray();
    }

    public void PassMessage(IMessage message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.PassMessage(message);
        }
    }
}