const gulp          = require('gulp');
const babel         = require('gulp-babel');
const concat        = require('gulp-concat');
const concatCss     = require('gulp-concat-css');
const rename        = require('gulp-rename');
const uglify        = require('gulp-uglify');
const cssNano       = require('gulp-cssnano');

// Concatenate & Minify src and dependencies
gulp.task('scripts', function() {
	return gulp.src([
		'leafletVelocity/src/js/**.js'
	])
	.pipe(concat('leaflet-velocity.js'))
	.pipe(babel({
		presets: ['es2015']
	}))
	.pipe(gulp.dest('leafletVelocity/dist'))
	.pipe(rename('leaflet-velocity.min.js'))
	.pipe(uglify())
	.pipe(gulp.dest('leafletVelocity/dist'));
});

gulp.task('concatCss', function () {
	return gulp.src('leafletVelocity/src/css/*.css')
		.pipe(concatCss('leafletVelocity/src/leaflet-velocity.css'))
		.pipe(gulp.dest('leafletVelocity/dist'));
});

gulp.task('cssNano', ['concatCss'], function() {
	gulp.src('leafletVelocity/dist/leaflet-velocity.css')
		.pipe(cssNano())
		.pipe(rename({suffix: '.min'}))
		.pipe(gulp.dest('leafletVelocity/dist'));
});

// Default Task
gulp.task('default', ['scripts', 'concatCss', 'cssNano', 'watch']);

// Watch Files For Changes
gulp.task('watch', function() {
	// We watch both JS and HTML files.
	gulp.watch('leafletVelocity/src/js/*.js', ['scripts']);
	gulp.watch('leafletVelocity/src/css/*.css', ['concatCss', 'cssNano']);
});