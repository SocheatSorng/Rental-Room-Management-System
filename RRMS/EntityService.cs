using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRMS
{
    public class EntityService
    {
        public void InsertOrUpdateEntity<T>(T entity, string storedProcedure, string action) where T : IEntity
        {
            try
            {
                if (action == "Insert")
                {
                    Helper.InsertEntity(Program.Connection, entity, storedProcedure);
                    MessageBox.Show("Successfully Inserted Entity", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (action == "Update")
                {
                    Helper.UpdateEntity(Program.Connection, entity, storedProcedure);
                    // Assuming that the entity has a property called ResID or similar
                    var entityId = (entity as dynamic).ResID; // Use dynamic to access ResID
                    MessageBox.Show($"Successfully Updated Entity ID > {entityId}", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", action == "Insert" ? "Inserting" : "Updating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
