package com.greengecko.activitytest;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onStart() {
        super.onStart();
        Log.println(Log.DEBUG, "AT_LIFE", "MainActivity onStart() function called.");
    }

    @Override
    protected void onStop() {
        super.onStop();
        Log.println(Log.DEBUG, "AT_LIFE", "MainActivity onStop() function called.");
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        Log.println(Log.DEBUG, "AT_LIFE", "MainActivity onDestroy() function called.");
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Log.println(Log.DEBUG, "AT_LIFE", "MainActivity onCreate() function called.");
    }

    public void onButtonClickCall(View view) {
        Uri uri = Uri.parse("tel:010-1234-5678");
        Intent intent = new Intent(Intent.ACTION_DIAL, uri);
        startActivity(intent);
    }

    public void onButtonClickFinish(View view) {
        finish();
    }
}