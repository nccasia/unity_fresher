package com.unity3d.player;

import vn.vntac.sdk.model.User;

public interface ISdkLoginCallback {
    void callback(boolean isOK, String response, String message, int errorCode, User user);
}
