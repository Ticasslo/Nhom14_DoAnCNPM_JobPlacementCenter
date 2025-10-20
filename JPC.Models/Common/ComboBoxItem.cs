using System;

namespace JPC.Models.Common
{
    /// <summary>
    /// Helper class cho ComboBox để lưu trữ cả Text và Value
    /// </summary>
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        
        public ComboBoxItem()
        {
            Text = string.Empty;
            Value = 0;
        }
        
        public ComboBoxItem(string text, int value)
        {
            Text = text ?? string.Empty;
            Value = value;
        }
        
        public override string ToString()
        {
            return Text;
        }
        
        public override bool Equals(object obj)
        {
            if (obj is ComboBoxItem other)
            {
                return Value == other.Value && Text == other.Text;
            }
            return false;
        }
        
        public override int GetHashCode()
        {
            return Value.GetHashCode() ^ Text.GetHashCode();
        }
    }
}
