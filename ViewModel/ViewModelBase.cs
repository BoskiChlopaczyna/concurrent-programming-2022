﻿using BallSimulator.Presentation.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BallSimulator.Presentation.ViewModel;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, IValidator<T> validator, T def, [CallerMemberName] string propertyName = "")
    {
        if (validator.IsInvalid(value)) value = def;
        return SetField(ref field, value, propertyName);
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
