﻿namespace Commands {

    // команда которую пользователь может выполнить, введя имя команды в консоли
    public interface ICommand {
        string Name { get; }
        string Help { get; }
        string Description { get; }
        string[] Synonyms { get; }

        void Execute (params string[] parameters);
    }
}