package com.example.toastshapechange;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("토스트 모양변경");

        final Button button1 = findViewById(R.id.button1);
        button1.setOnClickListener(this::onClick);
    }

    private void onClick(View view) {
        LinearLayout layout = (LinearLayout)getLayoutInflater().inflate(R.layout.toastlayout, null);

        Toast toast = Toast.makeText(this, "TOAST!!", Toast.LENGTH_SHORT);
        toast.setView(layout);
        toast.show();
    }
}