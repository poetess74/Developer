package com.example.selectanimal;

import android.app.TabActivity;
import android.os.Bundle;
import android.widget.TabHost;

public class MainActivity extends TabActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        TabHost host = getTabHost();

        TabHost.TabSpec cat = host.newTabSpec("CAT").setIndicator("고양이");
        cat.setContent(R.id.cat);
        host.addTab(cat);

        TabHost.TabSpec dog = host.newTabSpec("DOG").setIndicator("개");
        dog.setContent(R.id.dog);
        host.addTab(dog);

        TabHost.TabSpec rabbit = host.newTabSpec("RABBIT").setIndicator("토끼");
        rabbit.setContent(R.id.rabbit);
        host.addTab(rabbit);

        TabHost.TabSpec fox = host.newTabSpec("FOX").setIndicator("여우");
        fox.setContent(R.id.fox);
        host.addTab(fox);

        host.setCurrentTab(0);
    }
}