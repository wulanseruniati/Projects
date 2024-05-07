namespace automotive;

public class Speed {
    public float velocity;

    public Speed(float velocity) {
        this.velocity = velocity;
    }

    public float addVelocity(float velocity) {
        this.velocity += velocity;
        return this.velocity;
    }
}