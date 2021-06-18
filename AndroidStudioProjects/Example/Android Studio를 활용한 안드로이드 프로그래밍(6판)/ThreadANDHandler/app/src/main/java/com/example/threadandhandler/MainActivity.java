package com.example.threadandhandler;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {
    private TextView mainText, backText;
    private Button increase;

    private int mainValue;
    private int backValue;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("Thread&Handler");
        init();
        BackRunnable runnable = new BackRunnable();
        Thread thread = new Thread(runnable);
        thread.setDaemon(true);
        thread.start();
        setAction();
    }

    private void init() {
        mainText = findViewById(R.id.mainValue);
        backText = findViewById(R.id.backValue);
        increase = findViewById(R.id.increase);
    }

    private void setAction() {
        increase.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mainValue++;
                mainText.setText("MainValue : " + mainValue);
            }
        });
    }

    private class BackRunnable implements Runnable {
        @Override
        public void run() {
            while(true) {
                backValue++;
                Message msg = new Message();
                msg.what = 0;
                msg.arg1 = backValue;
                msg.obj = "d";
                handler.sendMessage(msg);
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    private Handler handler = new Handler() {
        @Override
        public void handleMessage(@NonNull Message msg) {
            if(msg.what == 0) {
                backText.setText("BackValue : " + msg.arg1);
            }
        }
    };
}