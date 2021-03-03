# asuka

Asuka is the collection of little utilities and extensions I use when working in Unity.

The goal is to create a Unity Package that I could easily plug into any project and avoid reimplementing same things over and over again. It should be as easy as to put Asuka into Eva.


## Third-Party Extensions

I am trying to avoid third-party dependencies in this package. Still need to find a way to share my extensions for third-party libraries. For now, I will just put them below.

### UniRx
UGUI
```csharp
public static IDisposable BindTo(this IReactiveCommand<int> command, Dropdown dropdown)
{
    var d1 = command.CanExecute.SubscribeToInteractable(dropdown);
    var d2 = dropdown.OnValueChangedAsObservable().SubscribeWithState(command, (x, c) => c.Execute(x));
    return StableCompositeDisposable.Create(d1, d2);
}

public static IDisposable BindTo(this IReactiveCommand<string> command, InputField inputField)
{
    var d1 = command.CanExecute.SubscribeToInteractable(inputField);
    var d2 = inputField.OnValueChangedAsObservable().SubscribeWithState(command, (x, c) => c.Execute(x));
    return StableCompositeDisposable.Create(d1, d2);
}

public static IDisposable SubscribeToImage(this IObservable<Sprite> source, Image image)
{
    return source.SubscribeWithState(image, (x, i) => image.sprite = x);
}
```


Input System
```csharp
public static IObservable<InputAction.CallbackContext> PerformedAsObservable(this InputAction action) =>
    Observable.FromEvent<InputAction.CallbackContext>(
            h => action.performed += h,
            h => action.performed -= h);

public static IObservable<Unit> PerformedAsUnitObservable(this InputAction action) => 
    action.PerformedAsObservable().AsUnitObservable();
```
