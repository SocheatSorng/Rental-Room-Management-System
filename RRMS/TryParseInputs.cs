using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class InputValidator
{
    // Method to validate inputs
    public bool TryParseInputs(Dictionary<string, string> inputs, out Dictionary<string, string> parsedValues)
    {
        parsedValues = new Dictionary<string, string>();

        foreach (var input in inputs)
        {
            string key = input.Key;
            string value = input.Value;

            // Check if the input is null or empty
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show($"{key} must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Add the validated input to the parsedValues dictionary
            parsedValues[key] = value;
        }

        return true;
    }
}