namespace CliningContoraFromValera.Bll
{
    public enum StatusType
    {
        Processed,
        InProgress,
        Done,
        Обработка,
        Выполняется,
        Готов,
        Отменён
    }

    public enum ServiceType
    {
        DryCleaning,
        Cleaning,
        Disinsection,
        Сухая_уборка,
        Уборка,
        Дезинсекция
    }

    public enum UnitType
    {
        шт,
        м2
    }
    public enum ClientOrderType
    {
        ЮрЛицо,
        ФизЛицо
    }
}
