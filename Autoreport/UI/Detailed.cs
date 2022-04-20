using Autoreport.Database;
using Autoreport.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Autoreport.UI
{
    public partial class Detailed : Form
    {
        object entity;

        public Detailed(object entity)
        {
            InitializeComponent();
            this.entity = entity;
        }

        private void AddData(string fieldDesc, string data)
        {
            Panel panel = new Panel();
            Label label1 = new Label();
            Label label2 = new Label();

            flowLayoutPanel1.Controls.Add(panel);

            panel.Controls.Add(label2);
            panel.Controls.Add(label1);
            panel.Dock = DockStyle.Top;
            panel.Location = new Point(3, 3);
            panel.Name = "panel";
            panel.Size = new Size(461, 26);
            panel.TabIndex = 0;

            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(200, 0);
            label2.Name = "label2";
            label2.Size = new Size(261, 26);
            label2.TabIndex = 1;
            label2.Text = data;
            label2.TextAlign = ContentAlignment.MiddleLeft;

            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Name = "label1";
            label1.Size = new Size(200, 26);
            label1.TabIndex = 0;
            label1.Text = fieldDesc;
            label1.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void AddData(string fieldDesc, IEnumerable data)
        {
            Panel panel = new Panel();
            Label label = new Label();
            ListBox listBox = new ListBox();

            flowLayoutPanel1.Controls.Add(panel);

            panel.Controls.Add(listBox);
            panel.Controls.Add(label);
            panel.Dock = DockStyle.Top;
            panel.Name = "panel1";
            panel.Size = new Size(461, 140);
            panel.TabIndex = 0;

            listBox.Dock = DockStyle.Fill;
            listBox.Location = new Point(200, 0);
            listBox.Name = "listBox";
            listBox.Size = new Size(261, 140);
            listBox.TabIndex = 1;
            listBox.HorizontalScrollbar = true;

            if (data != null)
                foreach (var listItem in data)
                {
                    listBox.Items.Add(listItem);
                }

            label.Dock = DockStyle.Left;
            label.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label.Location = new Point(200, 0);
            label.Name = "label";
            label.Size = new Size(200, 26);
            label.TabIndex = 1;
            label.Text = fieldDesc;
            label.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void Detailed_Load(object sender, EventArgs e)
        {
            string data;

            foreach (PropertyInfo property in entity.GetType().GetProperties())
            {
                if (property.GetCustomAttributes().OfType<KeyAttribute>().Count() > 0)
                    continue;

                Attribute propDisplayNameAttr = property.GetCustomAttributes()
                    .FirstOrDefault(x => x is DisplayNameAttribute);

                if (propDisplayNameAttr == null)
                    continue;

                string propDisplayName = ((DisplayNameAttribute)propDisplayNameAttr).DisplayName;

                if (property.PropertyType != typeof(string) && 
                        typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    AddData(propDisplayName, property.GetValue(entity, null) as IEnumerable);
                } else
                {
                    // Используется для конвертации Enum значений в строку.
                    // Для этого Enum должен обладать атрибутом TypeConverter, конвертирующим
                    // данное значение в Description, которое предназначено для этого значения.
                    // Прочие объекты, такие как числа, также успешно конвертируются
                    data = TypeDescriptor.GetConverter(property.GetValue(entity, null))
                        .ConvertToString(property.GetValue(entity, null));

                    AddData(propDisplayName, data);
                }
            }
        }
    }
}
