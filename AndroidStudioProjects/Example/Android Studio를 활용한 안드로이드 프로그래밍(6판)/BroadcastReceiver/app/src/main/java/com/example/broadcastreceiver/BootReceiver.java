package com.example.broadcastreceiver;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;

public class BootReceiver extends BroadcastReceiver {
    @Override
    public void onReceive(Context context, Intent intent) {
        Intent subTent = new Intent(context, MainActivity.class);
        subTent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        context.startActivity(subTent);
    }
}
