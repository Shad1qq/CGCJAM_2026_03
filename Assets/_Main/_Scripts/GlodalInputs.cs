public static class GlodalInputs
{
    private static InputSystem_Actions _actions = null;

    public static void Init()
    {
        _actions = new InputSystem_Actions();
        _actions.Enable();
    }
    public static bool CheckStatus()
    {
        if (_actions == null)
            return false;
        else
            return true;
    }
    public static InputSystem_Actions GetInput()
    {
        return _actions;
    }
    public static void Remove()
    {
        _actions.Disable();
        _actions = null;
    }

}
