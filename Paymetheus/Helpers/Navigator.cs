using System.Windows.Controls;

namespace Paymetheus.Helpers
{
    public class Navigator
    {
        private static Navigator _instance;
        private Frame _frame;
        private Navigator(Frame frame)
        {
            _frame = frame;
        }

        public static Navigator GetInstance(Frame frame = null)
        {
            if (_instance == null)
                _instance = new Navigator(frame);
            return _instance;
        }
        
        public void NavigateTo(Page page)
        {
            _frame.Content = page;
        }

    }
}
