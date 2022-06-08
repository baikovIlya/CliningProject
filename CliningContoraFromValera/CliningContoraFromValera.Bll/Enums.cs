namespace CliningContoraFromValera.Bll
{
    public enum StatusType
    {
        Обработка,
        Выполняется,
        Готов,
        Отменён
    }

    public enum ServiceType
    {
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
