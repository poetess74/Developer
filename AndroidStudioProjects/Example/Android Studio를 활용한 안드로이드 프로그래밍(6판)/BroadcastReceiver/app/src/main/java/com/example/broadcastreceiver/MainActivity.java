package com.example.broadcastreceiver;

import androidx.appcompat.app.AppCompatActivity;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.BatteryManager;
import android.os.Bundle;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {
    TextView plugged, status, level;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("배터리 상태 체크");
        init();
        registerReceiver(batteryReceiver, new IntentFilter(Intent.ACTION_BATTERY_CHANGED));
    }

    private void init() {
        plugged = findViewById(R.id.pluggedText);
        status = findViewById(R.id.statusText);
        level = findViewById(R.id.levelText);
    }

    @Override
    protected void onStop() {
        super.onStop();
        unregisterReceiver(batteryReceiver);
    }

    private BroadcastReceiver batteryReceiver = new BroadcastReceiver() {
        Intent intent = null;
        @Override
        public void onReceive(Context context, Intent intent) {
            this.intent = intent;
            plugged.setText(getPlugged());
            status.setText(getStatus());
            level.setText(getLevel());
        }

        public String getPlugged() {
            int plugged = intent.getIntExtra(BatteryManager.EXTRA_PLUGGED, 0);
            switch (plugged) {
                case BatteryManager.BATTERY_PLUGGED_AC: return "A/C 연결됨";
                case BatteryManager.BATTERY_PLUGGED_USB: return "USB 연결됨";
            }
            return null;
        }

        public String getStatus() {
            int status = intent.getIntExtra(BatteryManager.EXTRA_STATUS, 0);
            switch (status) {
                case BatteryManager.BATTERY_STATUS_UNKNOWN: return "알 수 없음";
                case BatteryManager.BATTERY_STATUS_CHARGING: return "충전 중";
                case BatteryManager.BATTERY_STATUS_DISCHARGING: return "방전 중";
                case BatteryManager.BATTERY_STATUS_NOT_CHARGING: return "충전 중이 아님";
                case BatteryManager.BATTERY_STATUS_FULL: return "충전 완료 됨";
            }
            return null;
        }

        public String getLevel() {
            int level = intent.getIntExtra(BatteryManager.EXTRA_LEVEL, 0);
            return String.format(" %d", level);
        }
    };
}