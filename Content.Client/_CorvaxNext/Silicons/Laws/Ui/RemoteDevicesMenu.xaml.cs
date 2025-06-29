// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-FileCopyrightText: 2025 ImHoks <142083149+ImHoks@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 ImHoks <imhokzzzz@gmail.com>
// SPDX-FileCopyrightText: 2025 KillanGenifer <killangenifer@gmail.com>
// SPDX-FileCopyrightText: 2025 ReserveBot <211949879+ReserveBot@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 ImHoks <imhokzzzz@gmail.com>
// SPDX-FileCopyrightText: 2025 KillanGenifer <killangenifer@gmail.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Client.UserInterface.XAML;
using FancyWindow = Content.Client.UserInterface.Controls.FancyWindow;
using Robust.Client.AutoGenerated;
using Content.Shared._CorvaxNext.Silicons.Borgs.Components;

namespace Content.Client._CorvaxNext.Silicons.Laws.Ui;

[GenerateTypedNameReferences]
public sealed partial class RemoteDevicesMenu : FancyWindow
{
    public event Action<RemoteDeviceActionEvent>? OnRemoteDeviceAction;

    public RemoteDevicesMenu()
    {
        RobustXamlLoader.Load(this);
    }

    public void Update(EntityUid uid, RemoteDevicesBuiState state)
    {
        RemoteDevicesDisplayContainer.Children.Clear();

        if (state.DeviceList == null)
            return;

        foreach (var device in state.DeviceList)
        {
            var control = new RemoteDeviceDisplay(device.NetEntityUid, device.DisplayName);

            control.OnRemoteDeviceAction += action =>
            {
                OnRemoteDeviceAction?.Invoke(action);
            };

            RemoteDevicesDisplayContainer.AddChild(control);
        }
    }
}
