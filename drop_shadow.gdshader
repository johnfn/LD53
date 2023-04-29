shader_type canvas_item;

uniform vec4 shadow_color : source_color = vec4(0.0, 0.0, 0.0, 0.5);
uniform float shadow_offset_x : hint_range(-50.0, 50.0) = 10.0;
uniform float shadow_offset_y : hint_range(-50.0, 50.0) = 10.0;
uniform float blur_radius : hint_range(0.0, 50.0) = 5.0;
uniform int blur_iterations : hint_range(1, 50) = 5;

void fragment() {
    vec4 color_sum = vec4(0.0);
    float blur_weight_sum = 0.0;

    for (int i = 0; i < blur_iterations; i++) {
        float blur_weight = float(i) / float(blur_iterations);
        vec2 uv_offset = vec2(shadow_offset_x, shadow_offset_y) * blur_weight / blur_radius;
        vec2 uv_blurred = (UV + uv_offset) / vec2(textureSize(TEXTURE, 0));
        vec4 blurred_color = texture(TEXTURE, uv_blurred);

        color_sum += blurred_color * shadow_color * blur_weight;
        blur_weight_sum += blur_weight;
    }

    color_sum /= blur_weight_sum;

    COLOR = color_sum;
}