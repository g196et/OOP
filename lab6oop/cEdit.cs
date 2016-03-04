using Humans;
using System;

namespace Commands {

    internal class EditCommand<T> : ICommand
        where T : Human, new() {
        private Application app;

        public EditCommand (Application app) {
            this.app = app;
        }

        public string Name { get { return "edit"; } }

        public string Help {
            get {
                return "Редактирование полей объекта";
            }
        }

        public string[] Synonyms {
            get { return new string[] { }; }
        }

        public string Description {
            get {
                return "Необязательный параметр — индекс элемента. Предлагает перезаписать поля " +
                       "\nобъекта. При пустом вводе — сохраняет предыдущее значение поля.";
            }
        }

        public void Execute (params string[] parameters) {
            while (parameters.Length == 0) {
                Console.WriteLine("Введите индекс элемента");
                parameters = Console.ReadLine().Split(new char[] { ' ' }, 1, StringSplitOptions.RemoveEmptyEntries);
            }
            try {
                if (parameters[0] != null)
                    Humans.deque[int.Parse(parameters[0])].Print();
            } catch {
                Console.WriteLine("Указанного элемента не существует или произведен некоректный ввод. Попробуйте еще раз");
            }
        }
    }
}