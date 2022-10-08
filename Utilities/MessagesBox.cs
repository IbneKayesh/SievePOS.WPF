using System.Windows;

namespace SievePOS.Utilities
{
    public class MessagesBox
    {
        public static MessageBoxResult Deleted(string caption)
        {
          return  MessageBox.Show("Record successfully deleted.", caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static MessageBoxResult Exception(string exception,string caption)
        {
            return MessageBox.Show("Error occured -" + exception, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static MessageBoxResult DeleteConfirm(string caption)
        {
            return MessageBox.Show("Confirm delete of this record?", caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        public static MessageBoxResult Saved(string caption)
        {
            return MessageBox.Show("New record successfully saved.", caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static MessageBoxResult Updated(string caption)
        {
            return MessageBox.Show("Record successfully updated.", caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
