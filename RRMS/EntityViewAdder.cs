using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

public class EntityViewAdder<T>
{
    private DataGridView _dataGridView;
    private Func<T, object[]> _propertySelector;

    public EntityViewAdder(DataGridView dataGridView, Func<T, object[]> propertySelector)
    {
        _dataGridView = dataGridView;
        _propertySelector = propertySelector;
    }

    public void AddToView(T entity)
    {
        DataGridViewRow row = new DataGridViewRow();
        var values = _propertySelector(entity);
        row.CreateCells(_dataGridView, values);
        row.Tag = entity; // You can store the entire entity or a specific identifier
        _dataGridView.Rows.Add(row);
    }
}