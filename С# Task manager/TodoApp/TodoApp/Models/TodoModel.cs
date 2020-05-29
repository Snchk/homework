using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    class TodoModel: INotifyPropertyChanged
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;

		private bool _isDone ;
		private string _text;

		public BindingList<TodoModel> LoadData()
		{
			var fileExists = File.Exists(PATH);
			if (!fileExists)
			{
				File.CreateText(PATH).Dispose();
				return new BindingList<TodoModel>();
			}
			using (var reader = File.OpenText(PATH))
			{
				var fileText = reader.ReadToEnd();
				return JsonConvert.DeserializeObject<BindingList<TodoModel>>(fileText);
			}

		}

		public bool IsDone
		{
			get { return _isDone; }
			set
			{
				if (_isDone == value)
					return;
				_isDone = value;
				OnPropertyChanged("IsDone");
			}		
		}
		public string Text
		{
			get { return _text; }
			set
			{
				if (_text == value)
				
					return;
					_text = value;
					OnPropertyChanged("Text");
				
			}
		}
		
	}
}
