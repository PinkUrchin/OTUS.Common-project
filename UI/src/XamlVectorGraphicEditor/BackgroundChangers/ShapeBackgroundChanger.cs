using System;
using System.Windows.Media;
using System.Windows.Shapes;

struct ShapeBackgroundChanger : IBackgroundChanger
{
    private readonly Shape _component;
    private readonly Action _change;

    public Brush Background
    {
        get => _component.Fill;
        set
        {
            _component.Fill = value;
            _change?.Invoke();
        }
    }

    public ShapeBackgroundChanger(in Shape rect, Action change)
    {
        _component = rect;
        _change = change;
    }
}

