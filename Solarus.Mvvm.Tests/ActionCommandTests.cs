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

        [Test]
        public void CanExecute_WhenPredicateIsNull_ReturnsTrue()
        {
            Action<object> action = CreateAction();
            var command = new ActionCommand(action);

            bool result = command.CanExecute(null);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanExecute_WhenPredicateIsTrue_ReturnsTrue()
        {
            Action<object> action = CreateAction();
            bool TruePredicate(object o) => true;
            var command = new ActionCommand(action, TruePredicate);

            bool result = command.CanExecute(null);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanExecute_WhenPredicateIsFalse_ReturnsFalse()
        {
            Action<object> action = CreateAction();
            bool FalsePredicate(object o) => false;
            var command = new ActionCommand(action, FalsePredicate);

            bool result = command.CanExecute(null);

            Assert.IsFalse(result);
        }

        private static Action<object> CreateAction()
        {
            return o => { };
        }

        [Test]
        public void Execute_Always_InvokesAction()
        {
            bool isActionInvoked = false;
            void Action(object o) => isActionInvoked = true;
            var command = new ActionCommand(Action);

            command.Execute();

            Assert.IsTrue(isActionInvoked);
        }
    }
}
