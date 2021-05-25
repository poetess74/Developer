package com.example.thread;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.view.View;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {
    private TextView textView;
    private Handler handler;

    private int count = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        textView = findViewById(R.id.textView);
        handler = new Handler() {
            @Override
            public void handleMessage(@NonNull Message msg) {
                switch (msg.what) {
                    case 1:
                        count = msg.arg1;
                        textView.setText("Count : " + count);
                        break;
                }
            }
        };
    }

    public void onClick(View view) {
        if (view.getId() == R.id.setCountBtn) {
            new Thread() {
                @Override
                public void run() {
                    Message msg = Message.obtain(handler, 1);
                    msg.arg1 = 50;
                    handler.sendMessage(msg);
                }
            }.start();
        }
    }
}