package com.example.activitytransition;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class ThirdActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_third);
        Intent intent = getIntent();
        if (intent != null) {
            String title = intent.getStringExtra("title");
            Toast.makeText(getApplicationContext(), "전달받은 값: " + title, Toast.LENGTH_LONG).show();
        }
    }

    public void onThirdButtonClicked(View view) {
        finish();
    }
}