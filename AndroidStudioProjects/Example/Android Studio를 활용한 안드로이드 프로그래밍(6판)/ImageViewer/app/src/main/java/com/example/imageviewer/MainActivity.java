package com.example.imageviewer;

import android.view.View;
import android.widget.ImageButton;
import android.widget.ImageView;
import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;

public class MainActivity extends AppCompatActivity {
    ImageView view;
    ImageButton button;
    int angle;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        view = findViewById(R.id.imageView);
        button = findViewById(R.id.imageBtn);

        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                angle += 30;
                if(angle == 360) angle = 0;
                view.setRotation(angle);
            }
        });
    }
}