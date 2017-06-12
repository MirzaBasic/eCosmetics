package hci_ib130266.cosmetics;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentTransaction;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.view.MenuItem;

import hci_ib130266.cosmetics.Activitys.KorpaActivity;
import hci_ib130266.cosmetics.Activitys.NaruzbeActivity;
import hci_ib130266.cosmetics.Fragments.ProfileFragment;
import hci_ib130266.cosmetics.Fragments.ProizvodiViewPagerFragment;
import hci_ib130266.cosmetics.Helper.Sesija;
import hci_ib130266.cosmetics.R;

public class NavigationDrawerActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener {
    DrawerLayout mDrawer;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_nav_drawer);


       mDrawer= (DrawerLayout) findViewById(R.id.drawer_layout);

        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, mDrawer, null, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        mDrawer.setDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);
        ProizvodiViewPagerFragment fragment=new ProizvodiViewPagerFragment();
        FragmentTransaction ft=getSupportFragmentManager().beginTransaction();
        ft.replace(R.id.content,fragment).commit();
    }

    @Override
    public void onBackPressed() {
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
        }
    }





    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();


         if (id == R.id.nav_proizvodi) {


             ProizvodiViewPagerFragment fragment=new ProizvodiViewPagerFragment();
             FragmentTransaction ft=getSupportFragmentManager().beginTransaction();
             ft.replace(R.id.content,fragment).commit();




         }
        if (id == R.id.nav_profil) {
            ProfileFragment fragment=new ProfileFragment();
            FragmentTransaction ft=getSupportFragmentManager().beginTransaction();
            ft.replace(R.id.content,fragment).commit();
        }
        if (id == R.id.nav_logout) {

            Sesija.SaveUser(null);
            Intent intent=new Intent(NavigationDrawerActivity.this,MainActivity.class);
            startActivity(intent);
        }
        if (id == R.id.nav_korpa) {


            Intent intent=new Intent(NavigationDrawerActivity.this,KorpaActivity.class);
            startActivity(intent);
        }
        if (id == R.id.nav_narudzbe) {


            Intent intent=new Intent(NavigationDrawerActivity.this,NaruzbeActivity.class);
            startActivity(intent);
        }

        mDrawer.closeDrawer(GravityCompat.START);
        return true;
    }
    public void OpenDrawer(){

        mDrawer.openDrawer(GravityCompat.START);
    }
}
