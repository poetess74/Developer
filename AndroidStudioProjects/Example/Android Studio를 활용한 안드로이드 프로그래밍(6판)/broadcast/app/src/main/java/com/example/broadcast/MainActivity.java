package com.example.broadcast;

import androidx.appcompat.app.AppCompatActivity;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.BatteryManager;
import android.os.Bundle;
import android.widget.EditText;
import android.widget.ImageView;

public class MainActivity extends AppCompatActivity {
    ImageView   batteryGage;
    EditText    batteryStatus;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("배터리 상태 체크");

        batteryGage = findViewById(R.id.ivBattery);
        batteryStatus = findViewById(R.id.edtBattery);
    }

    @Override
    protected void onPause() {
        super.onPause();
        unregisterReceiver(broadcastReceiver);
    }

    @Override
    protected void onResume() {
        super.onResume();
        IntentFilter filter = new IntentFilter();
        filter.addAction(Intent.ACTION_BATTERY_CHANGED);
        registerReceiver(broadcastReceiver, filter);
    }

    BroadcastReceiver broadcastReceiver = new BroadcastReceiver() {
        @Override
        public void onReceive(Context context, Intent intent) {
            String action = intent.getAction();

            if(action.equals(Intent.ACTION_BATTERY_CHANGED)) {
                int remain = intent.getIntExtra(BatteryManager.EXTRA_LEVEL, 0);
                batteryStatus.setText(String.format("현재 충전량: %d\n", remain));

                if(remain >= 90) {
                    batteryGage.setImageResource(R.drawable.battery_100);
                } else if(remain >= 70) {
                    batteryGage.setImageResource(R.drawable.battery_80);
                } else if(remain >= 50) {
                    batteryGage.setImageResource(R.drawable.battery_60);
                } else if(remain >= 10) {
                    batteryGage.setImageResource(R.drawable.battery_20);
                } else {
                    batteryGage.setImageResource(R.drawable.battery_0);
                }

                int plug = intent.getIntExtra(BatteryManager.EXTRA_PLUGGED, 0);
                switch (plug) {
                    case 0: batteryStatus.append("전원 공급원: 배터리"); break;
                    case 1: batteryStatus.append("전원 공급원: A/C"); break;
                    case 2: batteryStatus.append("전원 공급원: USB"); break;
                }
            }
        }
    };
}