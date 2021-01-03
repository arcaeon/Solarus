using NUnit.Framework;
using System;

namespace Solarus.Mvvm.Tests
{
    [TestFixture]
    public class ActionCommandTests
    {
        [Test]
        public void ActionCommand_WhenActionIsNull_ThrowsArgumentNullException()
        {
            ActionCommand command;
            Assert.Throws<ArgumentNullException>(() => command = new ActionCommand(null));
        }
    }
}
