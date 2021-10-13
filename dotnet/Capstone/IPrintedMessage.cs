using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    // This interface stores the printed message method, which allows for each item to have their own message printed when that item
    // is purchased by the user.
    public interface IPrintedMessage
    {
        string PrintedMessage();
    }
}
