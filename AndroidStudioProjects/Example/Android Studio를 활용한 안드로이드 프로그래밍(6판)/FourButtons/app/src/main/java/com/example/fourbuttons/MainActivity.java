package com.example.fourbuttons;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }
    public void openSite(View view) {
        Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse("https://m.naver.com"));
        startActivity(intent);
    }
    public void callNumber(View view) {
        Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse("tel:131"));
        startActivity(intent);
    }
    public void openPhoto(View view) {
        Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse("content://media/internal/images/media"));
        startActivity(intent);
    }
    public void exit(View view) {
        finish();
    }
}